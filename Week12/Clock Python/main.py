import time
import tracemalloc
from clock import Clock

def main():
    tracemalloc.start()
    start_time = time.perf_counter()
    my_clock = Clock()
    
    t = 1
    while t < 10000:
        print(my_clock.get_time())
        my_clock.tick()
        t += 1
    end_time = time.perf_counter()
    elapsed_time = end_time - start_time
    current_memory, peak_memory = tracemalloc.get_traced_memory()
    tracemalloc.stop()

    # Print benchmark results
    print("\n--- Benchmark Results ---")
    print(f"Execution Time: {elapsed_time:.6f} seconds")
    print(f"Current Memory Usage: {current_memory / 1024:.2f} KB")
    print(f"Peak Memory Usage: {peak_memory / 1024:.2f} KB")



if __name__ == "__main__":
    main()