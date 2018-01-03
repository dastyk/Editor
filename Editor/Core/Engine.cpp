#include "Engine.h"
#include <Core\EngineException.h>
#include <Utilz\ThreadPool.h>
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
		catch (const Engine_Exception& e)
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
			subSystems.threadPool = new Utilz::ThreadPool(4);
			if (!subSystems.threadPool)
				THROWERROR("Could not create threadpool", -1);
		}
		if (!subSystems.fileSystem)
		{
			subSystems.fileSystem = CreateFileSystem(ResourceHandler::FileSystemType::Binary);
			if (!subSystems.fileSystem)
				THROWERROR("Could not create filesystem", -1);
			auto result = subSystems.fileSystem->Init("data.dat", ResourceHandler::Mode::READ);
			if (result < 0)
				THROWERROR("Could not init filesystem", result);
		}
		if (!subSystems.resourceHandler)
		{
			subSystems.resourceHandler = CreateResourceHandler(subSystems.fileSystem, subSystems.threadPool);
			if (!subSystems.resourceHandler)
				THROWERROR("Could not create resource handler", -1);
		}
	}
	void Engine::InitManagers()
	{
		if (!managers.entityManager)
		{
			managers.entityManager = EntityManager_CreateEntityManager_C();
			if (!managers.entityManager)
				THROWERROR("Could not create entity manager", -1);
		}

		if (!managers.transformManagers)
		{
			ECS::TransformManagerInitializationInfo ii;
			ii.entityManager = managers.entityManager;
			managers.transformManagers = TransformManager_CreateTransformManager_C(ii);
			if (!managers.transformManagers)
				THROWERROR("Could not create entity manager", -1);
		}
		if (!managers.sceneManager)
		{
			ECS::SceneManagerInitializationInfo ii;
			ii.entityManager = managers.entityManager;
			ii.transformManager = managers.transformManagers;
			managers.sceneManager = SceneManager_CreateSceneManager_C(ii);
			if (!managers.sceneManager)
				THROWERROR("Could not create scene manager", -1);
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
			if (res < 0)
				THROWERROR("Could not shutdown file system", res);
			delete subSystems.fileSystem;
		}
	}
	
}