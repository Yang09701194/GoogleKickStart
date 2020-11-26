#include "pch.h"

using namespace std;

#define ll long long
#define ar array
#include <string>;
#include <iostream>;
#include <vector>;
#include <queue>;

void solve3() {
	int n, w;
	cin >> n;
	cin >> w;
	vector<ll> x(n);
	for(auto& a : x)
		cin >> a;
	for(auto& a : x)
		a += -1;
	sort(x.begin(), x.end());
	ll ans = 1e18, ca = 0;
	priority_queue<ll, vector<ll>, greater<ll>> pq1, pq2;
	for (int i = 0; i < n; i++) {
		ca += x.back() - x[i];
		pq1.push(x[i]);
	}
	for (int i = 0; i < n; i++) {
		int j = (i + n - 1) % n;
		ll x2 = x[j] + (i ? w : 0);
		while (pq1.size() >0 && abs(x2 - pq1.top()) > abs(x2 - pq1.top() - w)) {
			ca +=abs(x2 - pq1.top() - w) - abs(x2 - pq1.top());
			pq2.push(pq1.top() + w);
			pq1.pop();
		}
		if (ca < ans)
			ans = ca;
		vector<ll> v;
		while ((int)pq2.size() && x[i] + w > pq2.top()) {
			v.push_back(pq2.top());
			ca -= pq2.top() - x2;
			ca += x[i] + w - pq2.top();
			pq2.pop();
		}
		ca += (x[i] + w - x2)*((int)pq1.size() - (int)pq2.size());
		for(auto& vi : v)
			pq1.push(vi);
	}
	cout << ans << endl;
}

int MainRun3() {
	ios::sync_with_stdio(0);
	std::cin.tie(0);

	int t = 1;
	cin >> t;
	for (int i = 0; i < t; i++) {
		cout << "Case #" << i << ": " << endl;
		solve3();
	}

	return 0;
}