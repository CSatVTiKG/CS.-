#pragma once

#include <iostream>
#include <fstream>
#include <iomanip>
#include "json.hpp"

using json = nlohmann::json;
using namespace std;
typedef long long int ll_int;

class Database
{
public:
	Database();
	Database(string n, int s);
	Database(json js);

	void show(int i);
	void show();
	void add(string db_name, int score);
	void add();
	void save();
	void best_score();//поиск пользователя с максимальными очками
	void show_best_score();
	void show_user();
	void update(int count, string name, int score);
	int get_count();
	int get_score();
	string get_name(int numb);
	
	json& get();

private:
	string name = "User_0"; 
	int score = 0;
	int best_id = 0;

	json j = R"(
	{
		"File": "Records",
		"Date": "24/05/2021",
		"List_users": 
		[
			
		]
	}
	)"_json;
};