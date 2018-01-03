#ifndef DECLDIR_CORE
#if defined DLL_EXPORT_CORE
#define DECLDIR_CORE_C extern "C" __declspec(dllexport)
#define DECLDIR_CORE __declspec(dllexport)
#else
#define DECLDIR_CORE_C extern "C" __declspec(dllimport)
#define DECLDIR_CORE __declspec(dllimport)
#endif
#endif