#include <iostream>
#include <stdio.h>
#include <windows.h>
#include <time.h>
#include <stdlib.h>

#include <thread>

#include "Controller.h"


int main()
{
	setlocale(0, "ru");



	User_system control;
	control.user_input();

	system("pause");
}

