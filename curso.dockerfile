FROM mcr.microsoft.com/dotnet/sdk:8.0 AS debug
WORKDIR /src

COPY ["SistemaAcademicoCursoMS/SistemaAcademicoCursoMS.csproj", "SistemaAcademicoCursoMS/"]
RUN dotnet restore "SistemaAcademicoCursoMS/SistemaAcademicoCursoMS.csproj"

COPY . .

# MUITO IMPORTANTE: Entrar na pasta para os comandos abaixo funcionarem
WORKDIR "/src/SistemaAcademicoCursoMS"

RUN dotnet build "SistemaAcademicoCursoMS.csproj" -c Release -o /app/build

# Porta correta para o Professor no seu Compose
ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://+:8060" ]
