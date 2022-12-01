#include <stdbool.h>
#include <stddef.h>
#include <stdint.h>
#include "vga.h"

extern int __start;
extern int __end;

void kernel_main(void)
{
	terminal_initialize();

	terminal_writestring("Lord Samuel");

	// terminal_writeint32(0);
	// terminal_writestring("\r");
	// terminal_writeint32(1);
	// terminal_writestring("\r");
	// terminal_writeint32(-9);
	// terminal_writestring("\r");
	// terminal_writeint32(10);
	// terminal_writestring("\r");
	// terminal_writeint32(-100);
	// terminal_writestring("\r");
}
