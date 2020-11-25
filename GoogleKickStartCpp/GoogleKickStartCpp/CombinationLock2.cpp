#include "pch.h"

using namespace std;

#define ll long long
#define ar array
#include <string>;
#include <iostream>;
#include <vector>;
#include <queue>;


#define vt vector
#define pb push_back
#define all(c) (c).begin(), (c).end()
#define sz(x) (int)(x).size()

#define F_OR(i, a, b, s) for (int i=(a); (s)>0?i<(b):i>(b); i+=(s))
#define F_OR1(e) F_OR(i, 0, e, 1)
#define F_OR2(i, e) F_OR(i, 0, e, 1)
#define F_OR3(i, b, e) F_OR(i, b, e, 1)
#define F_OR4(i, b, e, s) F_OR(i, b, e, s)
#define GET5(a, b, c, d, e, ...) e
#define F_ORC(...) GET5(__VA_ARGS__, F_OR4, F_OR3, F_OR2, F_OR1)
#define FOR(...) F_ORC(__VA_ARGS__)(__VA_ARGS__)
#define EACH(x, a) for (auto& x: a)

template<class T> bool umin(T& a, const T& b) {
	return b < a ? a = b, 1 : 0;
}



template<class A> void read(vt<A>& v);
template<class A, size_t S> void read(ar<A, S>& a);
template<class T> void read(T& x) {
	cin >> x;
}




void DBG() {
	cerr << "]" << endl;
}
template<class H, class... T> void DBG(H h, T... t) {
	cerr << to_string(h);
	if (sizeof...(t))
		cerr << ", ";
	DBG(t...);
}
#ifdef _DEBUG
#define dbg(...) cerr << "LINE(" << __LINE__ << ") -> [" << #__VA_ARGS__ << "]: [", DBG(__VA_ARGS__)
#else
#define dbg(...) 0
#endif

template<class T> void offset(ll o, T& x) {
	x += o;
}
template<class T> void offset(ll o, vt<T>& x) {
	EACH(a, x)
		offset(o, a);
}
template<class T, size_t S> void offset(ll o, ar<T, S>& x) {
	EACH(a, x)
		offset(o, a);
}

template<class T, class U> void vti(vt<T> &v, U x, size_t n) {
	v = vt<T>(n, x);
}
template<class T, class U> void vti(vt<T> &v, U x, size_t n, size_t m...) {
	v = vt<T>(n);
	EACH(a, v)
		vti(a, x, m);
}

const int d4i[4] = { -1, 0, 1, 0 }, d4j[4] = { 0, 1, 0, -1 };
const int d8i[8] = { -1, -1, 0, 1, 1, 1, 0, -1 }, d8j[8] = { 0, 1, 1, 1, 0, -1, -1, -1 };

void solve() {
	int n, w;
	cin >> n;
	cin >> w;
	vt<ll> x(n);
	EACH(a, x)
		cin >> a;
	EACH(a, x)
		a += -1;
	sort(all(x));
	ll ans = 1e18, ca = 0;
	priority_queue<ll, vt<ll>, greater<ll>> pq1, pq2;
	FOR(n) {
		ca += x.back() - x[i];
		pq1.push(x[i]);
	}
	FOR(n) {
		int j = (i + n - 1) % n;
		ll x2 = x[j] + (i ? w : 0);
		while (sz(pq1) && abs(x2 - pq1.top()) > abs(x2 - pq1.top() - w)) {
			ca += abs(x2 - pq1.top() - w) - abs(x2 - pq1.top());
			pq2.push(pq1.top() + w);
			pq1.pop();
		}
		umin(ans, ca);
		vt<ll> v;
		while (sz(pq2) && x[i] + w > pq2.top()) {
			v.pb(pq2.top());
			ca -= pq2.top() - x2;
			ca += x[i] + w - pq2.top();
			pq2.pop();
		}
		ca += (x[i] + w - x2)*(sz(pq1) - sz(pq2));
		EACH(vi, v)
			pq1.push(vi);
	}
	cout << ans << endl; 
}

int MainRun() {
	ios::sync_with_stdio(0);
	std::cin.tie(0);

	int t = 1;
	read(t);
	FOR(t) {
		cout << "Case #"<< i << ": " << endl;  
		solve();
	}

	return 0;
}