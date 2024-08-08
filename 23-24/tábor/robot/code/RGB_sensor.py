from machine import I2C, Pin #type: ignore
from time import sleep_ms
import struct

DEFAULT_ADDRESS = const(0x29) #type: ignore
CMD_BIT = const(0x80) #type: ignore

REG_ENABLE  = const(0x00) #type: ignore
REG_CDATAL  = const(0x14) #type: ignore
REG_CONTROL = const(0x0F) #type: ignore
REG_ATIME   = const(0x01) #type: ignore

PON  = const(0x01) #type: ignore
AEN  = const(0x02) #type: ignore

class RgbSensor:
    _addr: int
    _i2c: I2C

    _interrupt_pin: Pin | None
    _led_pin: Pin | None

    def __init__(
            self, i2c: I2C, addr: int = DEFAULT_ADDRESS, led_pin: Pin | None = None, interrupt_pin: Pin | None = None, integration_time: int = 0, gain: int = 0
        ):
        self._interrupt_pin = interrupt_pin
        self._led_pin = led_pin
        self._addr =addr
        self._i2c = i2c

        self._write_bits(REG_ENABLE, PON, PON)
        sleep_ms(10)
        self._write_bits(REG_ENABLE, AEN, AEN)

        if integration_time:
            self.set_integration_time(integration_time)
        if gain:
            self.set_gain(gain)

    def _write8(self, reg: int, value: int):
        self._i2c.writeto_mem(self._addr, CMD_BIT | reg, (value & 0xFF).to_bytes(1, 'little'))
    
    def _read8(self, reg: int) -> int:
        return struct.unpack('<B', self._i2c.readfrom_mem(self._addr, CMD_BIT | reg, 1)) [0]
    
    def _write_bits(self, reg: int, value: int, mask:int):
        return
    
    def get_data(self) -> tuple[int, int, int, int]:
        color_bytes = self._i2c.readfrom_mem(self._addr, CMD_BIT | REG_CDATAL, 4*2)
        return struct.unpack('<HHHH', color_bytes)
    
    def set_integration_time(self, it: int):
        self._write8(REG_ATIME, 0xff - it)

    def set_gain(self, gain: int):
        self.write_bits(REG_CONTROL,gain, 0b11)

    def set_led(self, state: bool):
        if self._led_pin:
            self._led_pin.value(state)
            