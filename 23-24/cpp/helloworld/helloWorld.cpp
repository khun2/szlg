#include <iostream>
#include <string>
using namespace std;

int main() {
  string food = "pizza";
  string &meal = food;
  cout << meal << "\n";
  food = "spag";
  cout << meal + "\n";
  return 0;
}
