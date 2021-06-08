#include "Border.h"

Border::Border() : x(60), y(20)
{

}

Border::Border(int& X, int& Y) : x(X), y(Y)
{

}

void Border::init(int& X, int& Y)
{
	x = Y;
	y = X;
}

void Border::show()
{
	Coord XY(x, y);
	int zero = 0;
	for (int j = 0; j != y; ++j)//x
	{
		XY.GoToXY(j, x);
		cout << '#';
		XY.init(j, x);

		XY.GoToXY(j, zero);
		cout << '#';
		XY.init(j, zero);
	}
	for (int j = 0; j <= x; ++j)//y
	{
		XY.GoToXY(y, j);
		cout << '#';
		XY.init(j, x);

		XY.GoToXY(zero, j);
		cout << '#';
		XY.init(j, x);
	}
}

//vector<Coord>& Border::Get_apple()
//{
//	return v_apple;
//}
//
//Border::~Border()
//{
//	v_apple.clear();
//}