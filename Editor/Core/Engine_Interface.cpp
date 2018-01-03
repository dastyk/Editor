#include <Core\Engine_Interface.h>
#include "Engine.h"

Core::Engine_Interface * CreateEngine(const EngineInitializationInfo & initinfo)
{
	return new Core::Engine(initinfo);
}
