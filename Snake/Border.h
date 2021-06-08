#pragma once
#include <iostream>
#include <vector>

#include "Coord.h"

using namespace std;
typedef unsigned int uns;

class Border
{
public:
    Border();
    Border(int& x, int& y);

    void init(int& x, int& y);
    void show();
    //vector<Coord>& Get_apple();

    //~Border();
private:
    //vector<Coord> v_apple;
    int x, y;
};
