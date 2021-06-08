#include "Actor.h"

Actor::Actor() : x(60), y(20), _X(60), _Y(20)
{
	border.init(_X, _Y);
	border.show();
	thread thrd = thread(th_func, std::ref(rot));
	CursorVisible(false);
	spawn();
	info();
	move(rot);
}
 
Actor::Actor(int X, int Y) : x(X), y(Y), _X(X), _Y(Y)
{
	border.init(_X, _Y);
	border.show();
	thread thrd = thread(th_func, std::ref(rot));
	CursorVisible(false);
	spawn();
	info();
	move(rot);
}

Actor::Actor(int X, int Y, int speed, string name, int numb) : x(X), y(Y), _X(X), _Y(Y), speed(speed), name("User_0"), numb(numb)
{
	border.init(_X, _Y);
	border.show();
	thread thrd = thread(th_func, std::ref(rot));
	CursorVisible(false);
	spawn();
	info();
	move(rot);
}


vector<Coord>& Actor::Get_apple()
{
	return v_apple;
}
void Actor::add_apple(int X, int Y)
{
	srand(time(0));
	int x = rand() % (X-2) + 1;
	int y = rand() % (Y-2) + 1;
	Coord coord(x, y);

	for (int i = 0; i < v_ABody.size(); ++i)
	{
		if (v_ABody[i] == coord)
		{
			for (int i = 1; i < _X-1; ++i)
			{
				for (int j = 1; j < _Y-1; ++j)
				{
					coord.init(i, j);
					for (int k = 0; k < v_ABody.size(); ++k)
					{
						if (v_ABody[k] == coord)
						{
							//system("pause");
							break;
						} else
						if (k == v_ABody.size() - 1)
						{
							//system("pause");
							i = _X;
							j = _Y;
						}
					}
				}
			}
		}
	}
	Get_apple().push_back(coord);

	coord.GoToXY(coord);
	std::cout << '$';
}

void Actor::spawn()
{
	Coord coord;
	add_apple(_X, _Y);
	x = _X;
	y = _Y;
	coord.GoToXY(x/=2, y/=2);
	v_ABody.push_back(coord);
}

void Actor::move()
{
	while (fail)
	{
		Coord coord;
		switch (rot)
		{
		case 1:
			coord.init(x, y -= 1);
			trigger(coord);
			break;
		case 2:
			coord.init(x, y += 1);
			trigger(coord);
			break;
		case 3:
			coord.init(x -= 1, y);
			trigger(coord);
			break;
		case 4:
			coord.init(x += 1, y);
			trigger(coord);
			break;
		case 0:
			coord.GoToXY(0, y + 1);
			system("pause");
			break;
		default:
			coord.GoToXY(0, y + 1);
			std::cout << "нет";
			break;
		}
		Sleep(100);
	}
}

void Actor::move(int& rot)
{
	Coord coord;
up:
	if (rot == 5)
		fail = true;
	Sleep(speed);
	while (fail)
	{
		switch (rot)
		{
		case 1:
			coord.init(x, y -= 1);
			trigger(coord);
			Sleep(speed+40);
			break;
		case 2:
			coord.init(x, y += 1);
			trigger(coord);
			Sleep(speed+40);
			break;
		case 3:
			coord.init(x -= 1, y);
			trigger(coord);
			Sleep(speed);
			break;
		case 4:
			coord.init(x += 1, y);
			trigger(coord);
			Sleep(speed);
			break;
		case 5: // заново
			system("cls");
			Clear();
			Reload();
			Sleep(1000);
			break;
		case 6: // пауза
			coord.GoToXY(0, _Y + 1);
			system("pause");
			break;
		}
	}
	coord.GoToXY(0, _Y+1);
	
	goto up;
}

void Actor::trigger(Coord& coord)
{
	v_ABody.push_back(coord);
	coord.GoToXY(v_ABody[v_ABody.size() - 1]);
	std::cout << 'O';
	if ((v_ABody[v_ABody.size() - 1].get_x() == v_apple[0].get_x()) && (v_ABody[v_ABody.size() - 1].get_y() == v_apple[0].get_y()))
	{
		coord.GoToXY(v_ABody[v_ABody.size() - 2]);
		std::cout << '*';
		v_apple.erase(v_apple.begin());
		++count;
		info();
		add_apple(_X, _Y);
	}
	else
	{
		coord.GoToXY(v_ABody[v_ABody.size() - 2]);
		std::cout << '*';
		coord.GoToXY(v_ABody.begin());
		std::cout << ' ';
		v_ABody.erase(v_ABody.begin());
	}
	coord.GoToXY(v_ABody[v_ABody.size() - 1]);
	std::cout << 'O';

	for (int i = 0; i < v_ABody.size() - 1; ++i)
	{
		if (v_ABody[i] == v_ABody[v_ABody.size() - 1])
		{
			fail = false;
			info();
			if (users.get_score() < count)
			{
				users.update(0, name, count);
			}
		}
	}

	if (v_ABody[v_ABody.size() - 1].get_x() == _X || v_ABody[v_ABody.size() - 1].get_x() == 0 || 
		v_ABody[v_ABody.size() - 1].get_y() == _Y || v_ABody[v_ABody.size() - 1].get_y() == 0)
	{
		fail = false;
		info();
		if (users.get_score() < count)
		{
			users.update(0, name, count);
		}
	}
}
void Actor::CursorVisible(bool visible)
{
	HANDLE handle = GetStdHandle(STD_OUTPUT_HANDLE);
	CONSOLE_CURSOR_INFO structCursorInfo;
	GetConsoleCursorInfo(handle, &structCursorInfo);
	structCursorInfo.bVisible = visible;
	SetConsoleCursorInfo(handle, &structCursorInfo);
}

void Actor::Clear()
{
	v_apple.erase(v_apple.begin(), v_apple.end());
	v_ABody.erase(v_ABody.begin(), v_ABody.end());
	count = 0;
	border.~Border();
}

void Actor::Reload()
{
	border.init(_X, _Y);
	border.show();
	CursorVisible(false);
	count = 0;
	spawn();
	info();
}

void Actor::info()
{
	Coord coord;

	if (fail == false)
	{
		coord.GoToXY(_X + 3, 0);
		std::cout << "ПОРАЖЕНИЕ";
	}
	if (count == win)
	{
		coord.GoToXY(_X + 3, 0);
		std::cout << "ПОБЕДА!!!";
		fail = false;
	}
	coord.GoToXY(_X + 3, 1);
	std::cout << "Лучший результат: " ;
	users.show_best_score();
	coord.GoToXY(_X + 3, 2);
	std::cout << "Собрано долларов: " << count;
	coord.GoToXY(_X + 3, 4);
	std::cout << "Выход - ESc";
	coord.GoToXY(_X + 3, 5);
	std::cout << "1. Начать заново";
	coord.GoToXY(_X + 3, 6);
	std::cout << "2. Пауза.";
}

Actor::~Actor()
{
	v_apple.clear();
	v_ABody.clear();
	count = 0;
	border.~Border();
}

void th_func(int& rot)
{
	//Coord coord;
	while (rot != 0)
	{
		char c = 0;
		switch (c = _getch())
		{
		case 'w':
			rot = 1;//вверх
			break;
		case 's':
			rot = 2;//вниз
			break;
		case 'a':
			rot = 3;//влео
			break;
		case 'd':
			rot = 4;//вправо
			break;
		case 27: // Esc
			system("cls");
			exit(0);
			break;
		case 49:// 1 (заново)
			system("cls");
			rot = 5;
			break;
		case 50:// 2 (пауза)
			rot = 6;
			break;
		default:
			break;
		}
	}

}