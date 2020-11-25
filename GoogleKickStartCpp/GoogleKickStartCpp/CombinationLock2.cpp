#include "pch.h"
#include "CombinationLock2.h"


#include <iostream>
#include <queue>
#include <string>
using std::priority_queue;
using namespace std;

CombinationLock2::CombinationLock2()
{
}


CombinationLock2::~CombinationLock2()
{
}


void solve() {
	int n, w;
	cin >> n; 
	cin >> w;
	vector<long long> x(n);
	for (auto& xe : x)
		cin >> xe;
	for (auto& xe : x)
		xe += -1;
	sort(x.begin(), x.end());
	long long ans = 1e18, ca = 0;
	priority_queue<long long, vector<long long>, greater<long long>> pq1, pq2;
	for (int i = 0; i < n; i++)
	{
		ca += x.back() - x[i];
		pq1.push(x[i]);
	}
	for (int i = 0; i < n; i++)
	{
		int j = (i + n - 1) % n;
		long long x2 = x[j] + (i ? w : 0);
		while (pq1.size() && abs(x2 - pq1.top()) > abs(x2 - pq1.top() - w)) {
			ca += abs(x2 - pq1.top() - w) - abs(x2 - pq1.top());
			pq2.push(pq1.top() + w);
			pq1.pop();
		}

		if (ans > ca)
			ans = ca;
		vector<long long> v;
		while (pq2.size() && x[i] + w > pq2.top()) {
			v.push_back(pq2.top());
			ca -= pq2.top() - x2;
			ca += x[i] + w - pq2.top();
			pq2.pop();
		}
		ca += (x[i] + w - x2)*((pq1).size() - (pq2).size());
		for (auto& vi : v)
			pq1.push(vi);
	}
	cout << ans << endl;  
}

int MainRun() {
	ios::sync_with_stdio(0);
	cin.tie(0);

	int t = 1;
	cin >> t;
	for (int i = 0; i < t; i++)
	{
		cout << "Case #"+  std::to_string(i + 1) + ": " << endl;
		solve();
	}
	return 0;
}
