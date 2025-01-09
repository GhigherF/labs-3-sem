#pragma once
#include "Error.h"
#include "In.h"
#include "Log.h"
#include "LT.h"
namespace Flexer
{
	void Exe(LT::LexTable& lextable, IT::IdTable& idtable, In::IN in);
}