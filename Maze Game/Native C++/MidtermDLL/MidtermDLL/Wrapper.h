#pragma once
#include "CheckpointTimeLogger.h"

#ifdef __cplusplus
extern "C"
{
#endif

	//Put your function here
	PLUGIN_API void ResetLogger(); //Resets logger
	PLUGIN_API void SaveCheckpointTime(float RTBC); //Save mose recent checkpoint
	PLUGIN_API float GetTotalTime(); //Gets total time for race
	PLUGIN_API float GetCheckpointTime(int index); //Get checkpoint time at index
	PLUGIN_API int GetNumCheckpoints(); //Get number of checkpoints saved


#ifdef __cplusplus
}
#endif