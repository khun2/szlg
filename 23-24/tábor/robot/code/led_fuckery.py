from machine import Pin, PWM #type: ignore
from time import sleep_ms #type: ignore

g = PWM(Pin(14, Pin.OUT), freq=2000)
b = PWM(Pin(15, Pin.OUT), freq=2000)
r = PWM(Pin(16, Pin.OUT), freq=2000)

r.duty_u16(0xffff)
g.duty_u16(0xffff)
b.duty_u16(0xffff)

while(True):
    r.duty_u16(0xffff)
    b.duty_u16(0xffff)
    sleep_ms(50)
    r.duty_u16(0x0000)
    b.duty_u16(0x0000)
    sleep_ms(50)
    


