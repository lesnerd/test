#include <stdio.h>
#define MAX 10
int f(int p, int q)
{
	if (p > q)
		return p;
	else
		return q;
}

void func(int &x)
{
	x = 20;
}

void main()
{
	//char *dd;
	//int a = 5, b = 10;
	//int k;
	//bool x = true;
	//bool y = f(a, b);
	//k = ((a*b) + (x + y));
	//printf("%d", k);


	//===================
	/*int a = 10;
	float b = 20;


	printf("%d",sizeof(a + b));*/


	//====================

	//int arr[] = {0,2,4,7,5,3};
	//int n, res = 0;
	//for (n = 0; n < 8; n++)
	//{
	//	res += arr[n];
	//}
	//printf("%d", res);

	//======================

	/*int x = 10;
	func(x);
	printf("%d",x);
*/
	//=============================

	//int num;
	//num = ++MAX;
	//printf(num);

	//===============================

	int a = 21;
	int c;
	c = a++;
	printf("%d", c);


}