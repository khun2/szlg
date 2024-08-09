from networking import recv_exact, recv_str, socks
from math import floor
import struct

def define_controls(ctrls: dict):
    sock = socks[0]
    if sock is None:
        return

    sock.write(struct.pack('!BH', 2, len(ctrls)))

    for n in ctrls:
        nb = str(n).encode('utf-8')

        ctrl = ctrls[n]
        val = ctrl._val

        ty = None
        res = None

        if ctrl.is_ty(bool):
            ty = b'\x00'
            res = struct.pack('!B', val)
        elif ctrl.is_ty(float):
            ty = b'\x01'
            res = struct.pack('!3f', val, float(ctrl._min), float(ctrl._max))
        elif ctrl.is_ty(int):
            ty = b'\x02'
            res = struct.pack('!3q', val, ctrl._min, ctrl._max)
        elif ctrl.is_ty(str):
            ty = b'\x03'
            res = val.encode('utf-8')
            res = struct.pack('!H', len(res)) + res
        elif ctrl.is_ty(tuple):
            ty = b'\x04'
            res = struct.pack(
                '!3B',
                floor(ctrl[0] * 255),
                floor(ctrl[1] * 255),
                floor(ctrl[2] * 255)
            )

        sock.write(struct.pack('!H', len(nb)) + nb + ty + res)

def dprint(x):
    print(x)

    s = socks[0]

    if s is None:
        return

    bs = str(x).encode('utf-8')
    l = struct.pack('!BH', 1, len(bs))

    s.write(l + bs)

def recv_change(ctrls: dict) -> bool:
    sock = socks[0]
    if sock is None:
        return False

    nm = recv_str(sock, False)
    if nm is None:
        return False

    ctrl = ctrls[nm]
    if ctrl.is_ty(bool):
        val = struct.unpack('!B', recv_exact(sock, 1))[0]
    elif ctrl.is_ty(float):
        val = struct.unpack('!f', recv_exact(sock, 4))[0]
    elif ctrl.is_ty(int):
        val = struct.unpack('!q', recv_exact(sock, 8))[0]
    elif ctrl.is_ty(str):
        val = recv_str(sock)
    elif ctrl.is_ty(tuple):
        val = struct.unpack('!3B', recv_exact(sock, 3))
        val = (
            val[0] / 255,
            val[1] / 255,
            val[2] / 255,
        )

    ctrl.update(val)
    return True

def recv_changes(ctrls: dict):
    while recv_change(ctrls):
        pass
