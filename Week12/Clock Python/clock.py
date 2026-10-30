from counter import Counter

class Clock:
    def __init__(self):
        self._hour = Counter("Hours")
        self._min = Counter("Minutes")
        self._sec = Counter("Seconds")

    def get_time(self) -> str:
        h = f"{self._hour.ticks:02d}"
        m = f"{self._min.ticks:02d}"
        s = f"{self._sec.ticks:02d}"
        return f"{h}:{m}:{s}"

    def restart(self):
        self._hour.reset()
        self._min.reset()
        self._sec.reset()

    def tick(self):
        # Clock tick logic with rollover
        self._sec.increment()
        if self._sec.ticks >= 60:
            self._sec.reset()
            self._min.increment()
            if self._min.ticks >= 60:
                self._min.reset()
                self._hour.increment()
                if self._hour.ticks >= 24:
                    self._hour.reset()