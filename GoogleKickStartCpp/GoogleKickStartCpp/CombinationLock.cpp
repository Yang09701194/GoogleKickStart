#include <bits/stdc++.h>
#include <ext/pb_ds/assoc_container.hpp>
#include <ext/pb_ds/tree_policy.hpp>

#include <iostream>
#include <algorithm>


#define ll long long
#define f first
#define s second
#define pb push_back
#define mp make_pair
#define pii pair<int,int>
#define pll pair<ll,ll>
#define vii vector<pii>
#define vll vector<pll>
#define all(v) v.begin(),v.end()
#define mem(v,x) memset(v,x,sizeof(v))
#define ar array
#define N 2000005
#define ordered_set tree<int, null_type,less<int>, rb_tree_tag,tree_order_statistics_node_update>
//list of functions: set.insert(val), *(set.find_by_order(order-1)), set.order_of_key(val)

//using namespace __gnu_pbds;
using namespace std;


ll solve2(int x[], int w, int n, ll l, ll r) {
	while (r - l > 3) {
		ll m1 = l + (r - l) / 3;
		ll m2 = r - (r - l) / 3;
		ll a1 = 0;
		ll a2 = 0;
		for (int i = 0; i < w; i++) {
			ll temp1 = min(abs(x[i] - m1), abs(n - x[i] + m1));
			temp1 = min(temp1, abs(x[i] + n - m1));
			a1 = a1 + temp1;
			temp1 = min(abs(x[i] - m2), abs(n - x[i] + m2));
			temp1 = min(temp1, abs(x[i] + n - m2));
			a2 = a2 + temp1;
		}
		if (a1 < a2) {
			r = m2;
		}
		else {
			l = m1;
		}
	}
	ll ans = LLONG_MAX;
	while (l <= r) {
		ll res = 0;
		for (int i = 0; i < w; i++) {
			ll temp1 = min(abs(x[i] - l), abs(n - x[i] + l));
			temp1 = min(temp1, abs(x[i] + n - l));
			res += temp1;
		}
		ans = min(ans, res);
		l++;
	}
	return ans;
}
void solve() {
	ll w, n;
	cin >> w >> n;
	ll x[w];
	for (int i = 0; i < w; i++) {
		cin >> x[i];
	}
	sort(x, x + w);
	ll pre[w];
	pre[0] = x[0];
	for (int i = 1; i < w; i++) {
		pre[i] = x[i] + pre[i - 1];
	}
	ll ans = LLONG_MAX;
	for (int i = 0; i < w; i++) {
		ll res = 0;
		ll val1 = (2 * x[i] - n) / 2;
		ll val2 = (n + 2 * x[i]) / 2;
		//        cout<<val1<<' '<<val2<<' ';
		int id = lower_bound(x, x + i + 1, val1) - x;
		if (id >= 0 && x[id] > val1) {
			id--;
		}
		if (id >= 0 && id < w) {
			res += (id + 1)*n - x[i] * (id + 1) + pre[id];
		}
		if (id + 1 <= i) {
			ll temp = pre[i] - (id >= 0 ? pre[id] : 0);
			ll num = i - id;
			res += x[i] * num - temp;
		}
		int id2 = lower_bound(x + i, x + w, val2) - x;
		if (id2 >= 0 && id2<w && x[id2] > val2) {
			id2--;
		}
		if (id2 == w)id2--;
		if (id2 >= 0 && id2 < w) {
			ll temp = pre[id2] - pre[i];
			ll num = id2 - i;
			res += temp - num * x[i];
		}
		if (id2 + 1 < w) {
			ll temp = pre[w - 1] - pre[id2];
			ll num = w - 1 - id2;
			res += num * n - temp + num * x[i];
		}
		//        cout<<res<<'\n';
		ans = min(ans, res);
	}
	cout << ans << '\n';
}
int main() {
	ios_base::sync_with_stdio(0);
	cin.tie(NULL);
	int t;
	cin >> t;
	for (int i = 1; i <= t; i++) {
		cout << "Case #" << i << ": ";
		solve();
	}
	return 0;
}

