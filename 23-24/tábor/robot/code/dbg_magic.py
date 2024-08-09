from math import ceil, floor, trunc

class DbgVal:

    def __init__(self, v, mn=None, mx=None, call=None):
        self._val = v

        if mn is not None and mx is not None:
            self._min = mn
            self._max = mx

        if call is not None:
            self._call = call

    def update(self, v):
        self._val = v
        if hasattr(self, '_call'):
            self._call(v)

    def is_ty(self, t):
        return isinstance(self._val, t)

    def __getattr__(self, name: str):
        if name == '_val' or name == '_min' or name == '_max' or name == '_call':
            return super().__getattribute__(name)
        else:
            return getattr(self._val, name)

    def __setattr__(self, name: str, value):
        if name == '_val' or name == '_min' or name == '_max' or name == '_call':
            super().__setattr__(name, value)
        else:
            setattr(self.val, name, value)

    def __abs__(self): return abs(self._val)
    def __add__(self, x): return self._val + x
    def __and__(self, x): return self._val & x
    def __bool__(self): return bool(self._val)
    def __ceil__(self): return ceil(self._val)
    def __divmod__(self, x): return (self._val // x, self._val % x)
    def __eq__(self, o): return self._val == o
    def __float__(self): return float(self._val)
    def __floor__(self): return floor(self._val)
    def __floordiv__(self, x): return self._val // x
    def __format__(self, f): return format(self._val, f)
    def __ge__(self, x): return self._val >= x
    def __gt__(self, x): return self._val > x
    def __hash__(self): return hash(self._val)
    def __index__(self): return int(self)
    def __int__(self): return int(self._val)
    def __invert__(self): return ~self._val
    def __le__(self, x): return self._val < x
    def __lshift__(self, x): return self._val << x
    def __lt__(self, x): return self._val < x
    def __mod__(self, x): return self._val % x 
    def __mul__(self, x): return self._val * x
    def __ne__(self, x): return self._val != x
    def __neg__(self): return -self._val
    def __or__(self, x): return self._val | x
    def __pos__(self): return +self._val
    def __pow__(self, x): return self._val ** x
    def __radd__(self, x): return x + self._val
    def __rand__(self, x): return x & self._val
    def __rdivmod__(self, x): return (x // self._val, x % self._val)
    def __repr__(self): return repr(self._val)
    def __rfloordiv__(self, x): return x // self._val
    def __rlshift__(self, x): return x << self._val
    def __rmod__(self, x): return x % self._val
    def __rmul__(self, x): return x * self._val
    def __ror__(self, x): return x | self._val
    def __round__(self): return round(self._val)
    def __rpow__(self, x): return x ** self._val
    def __rrshift__(self, x): return x >> self._val
    def __rshift__(self, x): return self._val >> x
    def __rsub__(self, x): return x - self._val
    def __rtruediv__(self, x): return x / self._val
    def __rxor__(self, x): return x ^ self._val
    def __str__(self): return str(self._val)
    def __sub__(self, x): return self._val - x
    def __matmul__(self, x): return self._val @ x
    def __truediv__(self, x): return self._val / x
    def __trunc__(self): return trunc(self._val)
    def __xor__(self, x): return self._val ^ x
    def to_bytes(self, l, o): return self._val.to_bytes(l, o)
    def __iadd__(self, b): self._val += b
    def __iand__(self, b): self._val &= b
    def __ifloordiv__(self, b): self._val //= b
    def __ilshift__(self, b): self._val <<= b
    def __imod__(self, b): self._val %= b
    def __imul__(self, b): self._val *= b
    def __imatmul__(self, b): self._val @= b
    def __ior__(self, b): self._val |= b
    def __ipow__(self, b): self._val **= b
    def __irshift__(self, b): self._val >>= b
    def __isub__(self, b): self._val -= b
    def __itruediv__(self, b): self._val /= b
    def __ixor__(self, b): self._val ^= b
    def __len__(self): return len(self._val)
    def __getitem__(self, i): return self._val[i]
    def __iter__(self): return iter(self._val)
