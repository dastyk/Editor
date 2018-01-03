#ifndef _CORE_ENGINE_EXCEPTION_H_
#define _CORE_ENGINE_EXCEPTION_H_
#include <string>
#define THROWERROR(msg, error) throw Core::Engine_Exception(msg, error, __LINE__, __FILE__)
namespace Core
{
	struct Engine_Exception
	{
		std::string msg;
		int line;
		std::string file;
		long error;
		Engine_Exception(const std::string& msg, long error, int line, const std::string&& file ) 
			:msg(msg),error(error),line(line),file(file)
		{

		}
	};
}
#endif