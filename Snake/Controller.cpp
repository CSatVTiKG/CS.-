#include "Controller.h"

void User_system::info()
{
	cout << "1. ������." << endl;
	cout << "2. ���������." << endl;
	//cout << "3. �������." << endl;
	cout << "3. �����." << endl;
}

void User_system::user_input()
{
	int num;
	bool ex = 1;
	info();
	while (ex)
	{
		while (true)
		{
			try
			{
				cin >> num;
				if (cin.fail())
					throw 1;
				system("cls");
				break;
			}
			catch (...)
			{
				system("cls");
				cout << "������������ ���� ������, ��������� �������.\n" << endl;
				cin.clear();
				cin.ignore();
				info();
			}
		}
		switch (num)
		{
		case 1:
		{
			name = users.get_name(numb);
			Actor actor(x, y, speed, name, numb);
			system("cls");
			break;
		}
		case 2:
		{
			settings();
			system("cls");
			info();
			break;
		}
		//case 3:
		//{
		//	int ent;
		//	while (true)
		//	{
		//		system("cls");
		//		users.show();
		//		try
		//		{
		//			cout << "\n1. �������� ������������.";
		//			cout << "\n3. ������� ������������";
		//			cout << "\n2. �����." << endl;
		//			cin >> ent;
		//			check_err();
		//		}
		//		catch (...)
		//		{
		//			cout << "������������ ���� ������, ��������� �������." << endl;
		//		}
		//		break;
		//	}
		//	switch (ent)
		//	{
		//	case 1:
		//	{
		//		while (true)
		//		{
		//			try
		//			{
		//				system("cls");
		//				cout << "������� ������� �� ��������: ";
		//				cin >> name;
		//				check_err();
		//				for (auto n : name)
		//				{
		//					if (n <= 'a' && n >= 'z')
		//					{
		//						cout << "�������� ����, �������� ���������";
		//					}
		//					if (n <= 'A' && n >= 'Z')
		//					{
		//						cout << "�������� ����, �������� ���������";
		//					}
		//				}
		//				cout << "��� �������: " << name;
		//				users.add(name, 0);
		//				
		//				users.save();
		//				Sleep(1000);
		//				break;
		//			}
		//			catch (...)
		//			{
		//				cout << "������������ ���� ������, ��������� �������." << endl;
		//			}
		//			break;
		//		}
		//		system("cls");
		//		info();
		//		break;
		//	}
		//	case 2:
		//	{
		//		system("cls");
		//		info();
		//		break;
		//	}
		//	case 3:
		//	{
		//		while (true)
		//		{
		//			int n;
		//			system("cls");
		//			users.show();
		//			try
		//			{
		//				cout << "������� ����� ������������: ";
		//				cin >> n;
		//				check_err();
		//				if (n > users.get_count())
		//				{
		//					cout << "������ ������������ ���.";
		//				}
		//				else
		//				{
		//					numb = users.get_count();
		//				}
		//				system("cls");
		//				info();
		//				break;
		//			}
		//			catch (...)
		//			{
		//				cout << "������������ ���� ������, ��������� �������." << endl;
		//				Sleep(2000);
		//			}
		//		}
		//		break;
		//	}
		//	default:
		//		system("cls");
		//		cout << "������ ������ �� ����������, ��������� ����///.\n" << endl;
		//		break;
		//	}
		//	break;
		//}
		case 3:
		{
			ex = 0;
			cout << "�� ��������" << endl;
			break;
		}
		default:
		{
			system("cls");
			cout << "������ ������ �� ����������.\n" << endl;
			info();
		}
		}
	}
}

inline void User_system::check_err()
{
	if (cin.fail())
	{
		cin.clear();
		cin.ignore();
		throw 1;
	}
}

void User_system::settings()
{
	unsigned int cmd;
	bool exit = true;
	system("cls");
	while (true)
	{
		while (exit)
		{
			try
			{
				cout << "1. ������ �������� �������� ����." << endl;
				cout << "2. ������� ��������� ����." << endl;
				cout << "3. �����." << endl;
				cin >> cmd;
				check_err();
				break;
			}
			catch (...)
			{
				system("cls");
				cout << "������������ ���� ������, ��������� �������.\n" << endl;
			}
		}
		system("cls");
		switch (cmd)
		{
		case 1:
		{
			try
			{
				cout << "������� ������ ����: ";
				cin >> x;
				check_err();
				cout << "������� ������ ����: ";
				cin >> y;
				check_err();
			}
			catch (...)
			{
				system("cls");
				cout << "��� ���������� ������������ ���� ������.\n" << endl;
			}
			system("cls");
			break;
		}
		case 2:
		{
			bool ex = true;
			while (ex)
			{
				bool exit = true;
				while (exit)
				{
					try
					{
						cout << "1. �������." << endl;
						cout << "2. ������." << endl;
						cout << "3. �����." << endl;
						cout << "4. �����." << endl;
						cin >> cmd;
						check_err();
						exit = false;
					}
					catch (...)
					{
						system("cls");
						cout << "������������ ���� ������, ��������� �������.\n" << endl;
					}
				}
				if (cmd <= 3 && cmd >= 1)
				{
					cout << "\n�� ������� " << cmd << " ������� ���������." << endl;
					speed = cmd * 80;
					Sleep(1000);
					ex = false;
					system("cls");
				}
				else if (cmd == 4)
				{
					ex = false;
					system("cls");
				}
				else
				{
					system("cls");
					cout << "������ ������ �� ����������, ��������� ����.\n" << endl;
				}
			}
			break;
		}
		case 3:
		{
			user_input();
			break;
		}
		default:
			system("cls");
			cout << "������ ������ �� ����������, ��������� �������.\n" << endl;
			break;
		}
	}
}

