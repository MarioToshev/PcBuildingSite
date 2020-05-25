using Data;
using PcBuildingSite.Data.Entities;
using PcBuildingSite.Data.Models.Component;
using PcBuildingSite.Models.Components;
using System.Collections.Generic;
using System.Text;
using Storage = PcBuildingSite.Models.Components.Storage;

namespace PcBuildingSite.Services
{
    public class ComponentService
    {
        private readonly AppDbContext context;
        public ComponentService(AppDbContext context)
        {
            this.context = context;
        }
        public bool SocketIsCompadable(CPU processor, Motherboard motherboard)
        {
            if (processor.socket == motherboard.socket)
            {
                return true;
            }
            return false;
        }
        public bool FormFactorIsCompadable(PcCase Case, Motherboard motherboard)
        {
            if (Case.formfactor == motherboard.formfactor)
            {
                return true;
            }
            return false;
        }
        public bool CrossfireOrSliSupport(Gpu gpu, Motherboard motherBoard)
        {
            if (gpu.SliCrossfireSupport == motherBoard.sliCrossfireSuport)
            {
                return true;
            }
            return false;
        }
        public string StackRam(List<RAM> RamInSlots)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ram in RamInSlots)
            {
                sb.Append(ram.model + ",");
            }
            return sb.ToString();
        }
        public string StackSSDs(List<SSD> SSDs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ssd in SSDs)
            {
                sb.Append(ssd.Model + ",");
            }
            return sb.ToString();
        }
        public string StackHDD(List<HDD> HDDs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hdd in HDDs)
            {
                sb.Append(hdd.Model + ",");
            }
            return sb.ToString();
        }
        public bool IsPowerEnough(PSU psu, CPU cpu, List<Gpu> gpus)
        {
            double psuPower = psu.PowerEfficiency;
            int powerconsumption = GetPower(cpu, gpus);
            if (psuPower > powerconsumption)
            {
                return true;
            }
            return false;
        }
        public int GetPower(CPU cpu, List<Gpu> gpus)
        {
            int CpuPower = cpu.tdp;
            int GpuPower = 0;
            foreach (var gpu in gpus)
            {
                GpuPower += gpu.tdp;
            }
            int PowerConsumption = CpuPower + CpuPower + 10;
            return PowerConsumption;
        }
        public double GetPerformance(CPU cpu, Gpu gpu, RAM ram)
        {
            double PerformanceScore = ((cpu.cores * cpu.frequency * 10) - cpu.tdp)
                + ((gpu.frequency * gpu.cores) - gpu.tdp + (gpu.rtCores * 2)) + ram.frequency * ram.memorysize;
            return PerformanceScore;
        }
        public void CreateGPU(GpuDto gpu)
        {
            this.context.gpus.Add(this.OfGpuDto(gpu));
            this.context.SaveChanges();
        }
        private Gpu OfGpuDto(GpuDto gpuDto)
        {
            return new Gpu()
            {
                model = gpuDto.model,
                frequency = gpuDto.frequency,
                vramSpeed = gpuDto.vramSpeed,
                cores = gpuDto.cores,
                rtCores = gpuDto.rtCores,
                memoryQuantity = gpuDto.memoryQuantity,
                tdp = gpuDto.tdp,
                SliCrossfireSupport = gpuDto.SliCrossfireSupport,
                price = gpuDto.price
            };
        }
        public void CreateCPU(CpuDto cpu)
        {
            this.context.cpus.Add(this.OfCpuDto(cpu));
            this.context.SaveChanges();
        }
        private CPU OfCpuDto(CpuDto cpu)
        {
            return new CPU()
            {
                model = cpu.model,
                socket = cpu.socket,
                frequency = cpu.frequency,
                cores = cpu.cores,
                threads = cpu.threads,
                cpuBrand = cpu.cpuBrand,
                generation = cpu.generation,
                tdp = cpu.tdp,
                price = cpu.price
            };
        }
        public void CreateMotherboard(MotherboardDto motherboard)
        {
            this.context.motherboards.Add(this.OfMotherboardDto(motherboard));
            this.context.SaveChanges();
        }
        private Motherboard OfMotherboardDto(MotherboardDto motherboard)
        {
            return new Motherboard()
            {
                model = motherboard.model,
                socket = motherboard.socket,
                ramSlots = motherboard.ramSlots,
                formfactor = motherboard.formfactor,
                sliCrossfireSuport = motherboard.sliCrossfireSuport,
                suportedGeneration = motherboard.suportedGeneration,
                price = motherboard.price
            };
        }
        public void CreateRam(RamDto ram)
        {
            this.context.rams.Add(this.OfRamDto(ram));
            this.context.SaveChanges();
        }
        private RAM OfRamDto(RamDto ram)
        {
            return new RAM()
            {
                model = ram.model,
               frequency = ram.frequency,
               memorysize = ram.memorysize,
                price = ram.price
            };
        }
        public void CreatePcCase(PcCaseDto pcCase)
        {
            this.context.cases.Add(this.OfPcCaseDto(pcCase));
            foreach (var caseModel in context.cases)
            {
                if (caseModel.model == pcCase.model)
                {
                    break;
                }
                this.context.SaveChanges();
            }
            
        }
        private PcCase OfPcCaseDto(PcCaseDto pcCase)
        {
            return new PcCase()
            {
                model = pcCase.model,
                formfactor = pcCase.formfactor,               
                price = pcCase.price
            };
        }
        public void CreatePcStorage(PcStorageDto storage)
        {
            this.context.storages.Add(this.OfPcStorageDto(storage));                        
                this.context.SaveChanges();
           

        }
        private PcStorage OfPcStorageDto(PcStorageDto storage)
        {
            return new PcStorage()
            {
                model = storage.model,
                memeorySize = storage.memeorySize,
                price = storage.price,
                readSpeed = storage.readSpeed,
                ssdOrHdd = storage.ssdOrHdd,
                writeSpeed = storage.writeSpeed
            };
        }
        public List<string> GetAllCpuModels()
        {
            List<CPU> cpuList = new List<CPU>();
            List<string> cpuModels = new List<string>();

            foreach (var cpu in context.cpus)
            {
                cpuList.Add(cpu);
            }
            foreach (var cpuSuggestion in cpuList)
            {
                cpuModels.Add(cpuSuggestion.model);
            }
            return cpuModels;
        }

    }
}
