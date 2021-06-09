#include "Users.h"

Database::Database()
{
    std::ifstream i("Users.json");
    i >> j;
    //std::ofstream o("Users.json");
    //o << setw(4) << j << std::endl;
}

Database::Database(string n, int c) :
    name(n), score(c)
{
    std::ifstream i("Users.json");
    i >> j;

    j["List_users"] += {name, { {"Best score", score}}};
}

Database::Database(json js)
{
    j = js;
}

void Database::show(int i)
{
    cout << j.dump(i);
}

void Database::show()
{
    int count = j["List_users"].size();
    for (int i = 0; i < count; ++i)
    {
        name = j["List_users"][i].begin().key();
        cout << name << ':';
        for (auto const& val : j["List_users"][i][name])
        {
            cout << ' ' << val << endl;
        }
        cout << endl;
    }
}

void Database::add(string name, int score)
{

    j["List_users"] += { {name, { {"Best score", score} }} };
}

void Database::add()
{

}

void Database::save()
{
    std::ofstream o("Users.json");
    o << setw(4) << j << std::endl;
}

void Database::best_score()
{
    int count = j["List_users"].size();
    int max = 0;
    int h = 0;
    for (int i = 0; i < count; ++i)
    {
        name = j["List_users"][i].begin().key();
        for (auto const& val : j["List_users"][i][name])
        {
            if (val >= max)
            {
                max = val;
                best_id = i;
            }
        }
    }
}

void Database::show_best_score()
{
    best_score();
    name = j["List_users"][best_id].begin().key();
    //cout << name << ": ";
    for (auto const& val : j["List_users"][best_id][name])
    {
        cout << val;
    }
}

void Database::show_user()
{
    name = j["List_users"][0].begin().key();
    cout << name << ": ";
    for (auto const& val : j["List_users"][0][name])
    {
        cout << val;
    }
}

void Database::update(int count, string name, int score)
{
    j["List_users"].erase(count);
    add(name, score);
    save();
}

int Database::get_count()
{
    int count = j["List_users"].size();
    return count;
}

int Database::get_score()
{
    int score;
    for (auto const& val : j["List_users"][0][name])
    {
        score = val;
    }
    return score;
}

string Database::get_name(int numb)
{
    return name = j["List_users"][numb].begin().key();;
}

json& Database::get()
{
    return j;
}
