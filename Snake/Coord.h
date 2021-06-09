#pragma once

#include <iostream>
#include <windows.h>
#include <vector>

using namespace std;
typedef unsigned int uns;

class Coord
{
public:
    Coord();
    Coord(int x, int y);

    void GoToXY(int x, int y);
    void GoToXY(Coord& coord);
    void GoToXY(vector<Coord>::iterator coord);
    void init(int& x, int& y);
    bool operator != (const Coord& coord);
    bool operator != (vector<Coord>::iterator coord);
    bool operator ==(Coord coord);


    Coord& get_coord();
    int& get_x();
    int& get_y();
    
private:
    int x, y;
};

