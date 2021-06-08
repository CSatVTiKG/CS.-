#include "Coord.h"

Coord::Coord() : x(0), y(0)
{
}

Coord::Coord(int X, int Y)
{
	x = X;
	y = Y;
}

Coord& Coord::get_coord()
{
	Coord coord(x, y);
	return coord;
}

int& Coord::get_x()
{
	return x;
}
int& Coord::get_y()
{
	return y;
}


void Coord::init(int& X, int& Y)
{
	x = X;
	y = Y;
}

bool Coord::operator!=(const Coord& coord)
{
	if (x != coord.x && y != coord.y)
		return true;
	else
		return false;
}

bool Coord::operator!=(vector<Coord>::iterator coord)
{
	if (x != (*coord).get_x() && y != (*coord).get_y())
		return true;
	else
		return false;
}

bool Coord::operator==(Coord coord)
{
	if (coord.get_x() == x && coord.get_y() == y)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void Coord::GoToXY(int X, int Y)
{
	COORD pos = { X, Y };
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(handle, pos);
}

void Coord::GoToXY(Coord& coord)
{
	COORD pos = { coord.get_x(), coord.get_y() };
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(handle, pos);
}

void Coord::GoToXY(vector<Coord>::iterator coord)
{
	COORD pos = { (*coord).get_x(), (*coord).get_y() };
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	SetConsoleCursorPosition(handle, pos);
}
