from machine import Pin, PWM, time_pulse_us #type:ignore
from time import sleep_us #type:ignore

M_PER_US = 0.0001715
MIN_DIST = 0.02
MAX_DIST = 4.0

class UltraSensor:
    trig:Pin
    echo:Pin

    def __init__(self, trig:Pin, echo:Pin):
        self.trig = trig
        self.echo = echo

    def measure_sync(self) -> float | None:
        self.trig.value(True)
        sleep_us(15)
        self.trig.value(False)

        dur_us = time_pulse_us(self.echo, 1, 60_000)
    
        m = dur_us * M_PER_US

        if m < MIN_DIST or m > MAX_DIST:
            return None
        return m