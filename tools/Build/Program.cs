Directory.CreateDirectory("bin");
Directory.CreateDirectory("obj");

AssembleBootLoader();
BuildKernel();
LinkKernel();

static void AssembleBootLoader()
{
    WriteLine(nameof(AssembleBootLoader));
    Execute("i686-elf-as", "boot/boot.s", "-o", "obj/boot.o");
}

static void BuildKernel()
{
    WriteLine(nameof(BuildKernel));

    List<string> options = new()
    {
        "-o", "obj/kernel.o",
        "-I", "include",
        "-std=gnu99",
        "-ffreestanding" ,
        "-O2" ,
        "-Wall",
        "-Wextra"
    };

    foreach (var sourceFile in Directory.GetFiles("src", "*.c"))
    {
        options.Add("-c");
        options.Add(sourceFile);
    }

    Execute("i686-elf-gcc", options.ToArray());
}

static void LinkKernel()
{
    WriteLine(nameof(LinkKernel));

    List<string> options = new()
    {
        "-T", "boot/linker.ld",
        "-o", "bin/minos.bin",
        "-ffreestanding",
        "-O2",
        "-nostdlib",
        "-lgcc",
        "obj/boot.o",
        "obj/kernel.o"
    };
    
    Execute("i686-elf-gcc", options.ToArray());
}