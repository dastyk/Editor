#ifndef _CORE_ENGINE_H_
#define _CORE_ENGINE_H_
#include <Core\Engine_Interface.h>
namespace Core
{
	class Engine : public Engine_Interface
	{
	public:
		Engine(const EngineInitializationInfo& initInfo);
		~Engine();

		void Shutdown()override;



		const SubSystems&	GetSubSystems()const override;
		const Managers&		GetManagers()const override;

	private:
		SubSystems subSystems;
		Managers managers;
		void InitSubSystems();
		void InitManagers();
		void DestroyManagers();
		void DestroySubSystems();
	};

}
#endif