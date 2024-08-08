from machine import Pin, PWM #type: ignore
from time import sleep_ms #type: ignore

class Led:
    r:PWM
    g:PWM
    b:PWM
    r_state:int
    g_state:int
    b_state:int

    def __init__(self, pin_r:int, pin_g:int, pin_b:int, freq:int):
        self.r = PWM(Pin(pin_r, Pin.OUT), freq=freq)
        self.g = PWM(Pin(pin_g, Pin.OUT), freq=freq)
        self.b = PWM(Pin(pin_b, Pin.OUT), freq=freq)
        self.turnoff()

    @staticmethod
    def set_brightness(channel:PWM, value:int):
        channel.duty_u16(int(0xffff * ((255 - value) / 255)))

    def set_rgb(self, r:int, g:int, b:int):
        self.r_state = r
        self.g_state = g
        self.b_state = b
        Led.set_brightness(self.r, r)
        Led.set_brightness(self.g, g)
        Led.set_brightness(self.b, b)

    def set_channel(self, channel:str, value:int):
        if (channel == 'R'):
            self.r_state = value
            Led.set_brightness(self.r, value)
        if (channel == 'G'):
            self.g_state = value
            Led.set_brightness(self.g, value)
        if (channel == 'B'):
            self.b_state = value
            Led.set_brightness(self.b, value)

    def turnoff(self):
        self.r.duty_u16(0xffff)
        self.g.duty_u16(0xffff)
        self.b.duty_u16(0xffff)
        self.r_state = 0
        self.g_state = 0
        self.b_state = 0

def sign(x:int):
    return (x > 0) - (x < 0)

led = Led(16, 14, 15, 2000)

table = [
    [255,   0,   0],
    [255, 255,   0],
    [  0, 255,   0],
    [  0, 255, 255],
    [  0,   0, 255],
    [255,   0, 255]
]

MAX_ITER = 3
DELAY = 2

led.set_rgb(table[0][0], table[0][1], table[0][2])

for i in range(1, MAX_ITER * 6):
    for j in range(255):
        tp = i % len(table)
        led.set_rgb(
            led.r_state + sign(table[tp][0] - led.r_state),
            led.g_state + sign(table[tp][1] - led.g_state),
            led.b_state + sign(table[tp][2] - led.b_state)
        )
        sleep_ms(DELAY)

led.turnoff()