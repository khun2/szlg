from machine import Pin, PWM #type: ignore
from time import sleep_ms #type: ignore

class Led:
    r:PWM
    g:PWM
    b:PWM

    def __init__(self, pin_r:int, pin_g:int, pin_b:int, freq:int):
        self.r = PWM(Pin(pin_r, Pin.OUT), freq=freq)
        self.g = PWM(Pin(pin_g, Pin.OUT), freq=freq)
        self.b = PWM(Pin(pin_b, Pin.OUT), freq=freq)
        self.r.duty_u16(0xffff)
        self.g.duty_u16(0xffff)
        self.b.duty_u16(0xffff)

    @staticmethod
    def set_brightness(channel:PWM, rate:float):
        channel.duty_u16(int(0xffff * ((255 - rate) / 255)))


#def ChengeBetweenColours(light:Led, Rbegin:int, Rend:int, Gbegin:int, Gend:int, Bbegin:int, Bend:int):
#    if(Rbegin != Rend):
#        for i in range()


thing = Led(16, 14, 15, 2000)
#colors: r, g, b
#red: 229, 0, 0
#orange: 255, 141, 0
#yellow: 255, 238, 0
#green: 2, 129, 33
#blue: 0, 76, 255
#purple 119, 00, 136 

thing.set_brightness(thing.r, 119)
thing.set_brightness(thing.b, 136)
sleep_ms(5000)

while(True):
    for i in range(255):
        thing.set_brightness(thing.b, i)
        sleep_ms(10)
    for i in range(255):
        thing.set_brightness(thing.r, i)
        sleep_ms(10)
    for i in range(255):
        thing.set_brightness(thing.b, 255-i)
        sleep_ms(10)
    for i in range(255):
        thing.set_brightness(thing.r, 255-i)
        sleep_ms(10)



