from machine import PWM, Pin #type: ignore

class Buzzer:
    _p: PWM

    def __init__(self, p: Pin, freq: int = 2000):
        self._p = PWM(p, freq=freq)

    def set_freq(self, freq: int):
        self._p.freq(freq)

    def set_volume(self, v: float):
        self._p.duty_u16(int(v * 0x7fff))

    def off(self):
        self._p.deinit()