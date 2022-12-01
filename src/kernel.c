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
}
