#ifndef _ENGINE_INTERFACE_H_
#define _ENGINE_INTERFACE_H_
#include <EntityManager_Interface.h>
#include <Managers\TransformManager_Interface.h>
#include <Managers\SceneManager_Interface.h>
#include <ResourceHandler\ResourceHandler_Interface.h>
#include <ResourceHandler\FileSystem_Interface.h>
#include <DLLExport.h>
struct Managers
{
	ECS::EntityManager_Interface*				entityManager			= nullptr;
	ECS::TransformManager_Interface*			transformManagers		= nullptr;
	ECS::SceneManager_Interface*				sceneManager			= nullptr;
};
struct SubSystems
{
	ResourceHandler::FileSystem_Interface*		fileSystem				= nullptr;
	ResourceHandler::ResourceHandler_Interface*	resourceHandler			= nullptr;
	Utilities::ThreadPool*						threadPool				= nullptr;
};

struct EngineInitializationInfo
{
	SubSystems		subSystems;
	Managers		managers;
};
namespace Core
{
	
	class Engine_Interface
	{
	public:
	
		virtual ~Engine_Interface() {};

		virtual void Shutdown() = 0;

		virtual const SubSystems&	GetSubSystems()const	= 0;
		virtual const Managers&		GetManagers()const		= 0;
	protected:
		Engine_Interface() {};
	};

}

DECLDIR_CORE Core::Engine_Interface* CreateEngine(const EngineInitializationInfo& initinfo = {});
#endif