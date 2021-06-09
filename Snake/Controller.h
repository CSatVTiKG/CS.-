#pragma once
#include <iostream>
#include "Actor.h"
using namespace std;

class User_system
{
public:
	void info();
	void user_input();
	void inline check_err();
	void settings();
private:
	unsigned int x = 60, y = 20;
	//unsigned int x = 5, y = 3;
	unsigned int speed = 80;
	int numb=0;
	string name = "";
	Database users;
};