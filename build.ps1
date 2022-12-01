mkdir -Force bin | Out-Null
mkdir -Force obj | Out-Null

i686-elf-as boot/boot.s -o obj/boot.o
i686-elf-gcc -c src/kernel.c -o obj/kernel.o -I include -std=gnu99 -ffreestanding -O2 -Wall -Wextra
i686-elf-gcc -T boot/linker.ld -o bin/minos.bin -ffreestanding -O2 -nostdlib obj/boot.o obj/kernel.o -lgcc
