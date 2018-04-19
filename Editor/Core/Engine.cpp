#include "Engine.h"
#include <ThreadPool.h>
namespace Core
{

	Engine::Engine(const EngineInitializationInfo & initInfo) : 
		subSystems(initInfo.subSystems),
		managers(initInfo.managers)
	{
		try
		{
			InitSubSystems();
			InitManagers();
		}
		catch (UERROR e)
		{
			Shutdown();
			throw e;
		}
	}

	Engine::~Engine()
	{
	}
	void Engine::Shutdown()
	{
		DestroyManagers();
		DestroySubSystems();
	}
	const SubSystems & Engine::GetSubSystems() const
	{
		return subSystems;
	}
	const Managers & Engine::GetManagers() const
	{
		return managers;
	}
	void Engine::InitSubSystems()
	{
		if (!subSystems.threadPool)
		{
			subSystems.threadPool = new Utilities::ThreadPool(4);
			if (!subSystems.threadPool)
				THROW_ERROR("Could not create threadpool");
		}
		if (!subSystems.fileSystem)
		{
			subSystems.fileSystem = CreateFileSystem(ResourceHandler::FileSystemType::Binary);
			if (!subSystems.fileSystem)
				THROW_ERROR("Could not create filesystem");
			auto result = subSystems.fileSystem->Init("data.dat", ResourceHandler::Mode::READ);
			if (result.hash != "Success"_hash)
				THROW_ERROR("Could not init filesystem");
		}
		if (!subSystems.resourceHandler)
		{
			subSystems.resourceHandler = CreateResourceHandler(subSystems.fileSystem, subSystems.threadPool);
			if (!subSystems.resourceHandler)
				THROW_ERROR("Could not create resource handler");
		}
	}
	void Engine::InitManagers()
	{
		if (!managers.entityManager)
		{
			managers.entityManager = EntityManager_CreateEntityManager_C();
			if (!managers.entityManager)
				THROW_ERROR("Could not create entity manager");
		}

		if (!managers.transformManagers)
		{
			ECS::TransformManager_InitializationInfo ii;
			ii.entityManager = managers.entityManager;
			managers.transformManagers = TransformManager_CreateTransformManager_C(ii);
			if (!managers.transformManagers)
				THROW_ERROR("Could not create entity manager");
		}
		if (!managers.sceneManager)
		{
			ECS::SceneManager_InitializationInfo ii;
			ii.entityManager = managers.entityManager;
			ii.transformManager = managers.transformManagers;
			managers.sceneManager = SceneManager_CreateSceneManager_C(ii);
			if (!managers.sceneManager)
				THROW_ERROR("Could not create scene manager");
		}
	}
	void Engine::DestroyManagers()
	{
		if (managers.sceneManager)
			delete managers.sceneManager;
		if (managers.transformManagers)
			delete managers.transformManagers;
		if (managers.entityManager)
			delete managers.entityManager;
	}
	void Engine::DestroySubSystems()
	{
		if (subSystems.resourceHandler)
			delete subSystems.resourceHandler;
		if (subSystems.threadPool)
			delete subSystems.threadPool;
		if (subSystems.fileSystem)
		{
			auto res = subSystems.fileSystem->Shutdown();
			if (res.hash != "Success"_hash)
				throw res;
			delete subSystems.fileSystem;
		}
	}
	
}