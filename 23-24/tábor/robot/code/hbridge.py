from machine import Pin, PWM #type: ignore
from utils import clamp

class HBridge:
    _r_pwm: PWM
    _l_pwm: PWM

    _l_1: Pin
    _l_2: Pin

    _r_1: Pin    
    _r_2: Pin

    def __init__ (self, l_pwm: Pin, r_pwm: Pin, l_1:Pin, l_2: Pin, r_1: Pin, r_2: Pin, freq: int = 2000):
        self._r_pwm = PWM(r_pwm, freq=freq)
        self._l_pwm = PWM(l_pwm, freq=freq)

        self._l_1 = l_1
        self._l_2 = l_2

        self._r_1 = r_1
        self._r_2 = r_2
    def drive(self, l: float, r: float):
        r = clamp(r, -1, 1)
        l = clamp(l, -1, 1)

        self._l_1.value(l < 0)
        self._l_2.value(l > 0)
        self._l_pwm.duty_u16(int(abs(l) * 0xffff))

        self._r_1.value(r > 0)
        self._r_2.value(r < 0)
        self._r_pwm.duty_u16(int(abs(r) * 0xffff))
    def brake(self):
        self._l_1.value(True)
        self._l_2.value(True)
        self._r_1.value(True)
        self._r_2.value(True)
        self._l_pwm.duty_u16(0)
        self._r_pwm.duty_u16(0)
    