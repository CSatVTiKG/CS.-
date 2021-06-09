#pragma once
#include <iostream>
#include <thread>
#include <conio.h>

#include "Users.h"
#include "Border.h"

void th_func(int& rot);

class Actor
{
public:
	Actor();
	Actor(int x, int y);
	Actor(int x, int y, int speed, string name, int numb);

	void add_apple(int X, int Y);
	vector<Coord>& Get_apple();
	void spawn();
	void move();
	void move(int& rot);
	void trigger(Coord& coord);
	void CursorVisible(bool visible);
	void Clear();
	void Reload();
	void info();

	~Actor();
private:
	int x, y;
	int _X = 60, _Y = 20;
	int rot = 4;
	int speed = 80;
	int count = 0;
	int numb = 0;
	int win = (_X-1) * (_Y-1);
	bool fail = true;
	string name = "User_0";
	vector<Coord> v_apple;
	vector<Coord> v_ABody;
	Border border;
	Database users;
};

