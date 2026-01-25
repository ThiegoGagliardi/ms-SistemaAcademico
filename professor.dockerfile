FROM mcr.microsoft.com/dotnet/sdk:8.0 AS debug
WORKDIR /src

COPY ["SistemaAcademicoProfessorMS/SistemaAcademicoProfessorMS.csproj", "SistemaAcademicoProfessorMS/"]
RUN dotnet restore "SistemaAcademicoProfessorMS/SistemaAcademicoProfessorMS.csproj"

COPY . .

# MUITO IMPORTANTE: Entrar na pasta para os comandos abaixo funcionarem
WORKDIR "/src/SistemaAcademicoProfessorMS"

RUN dotnet build "SistemaAcademicoProfessorMS.csproj" -c Release -o /app/build

# Porta correta para o Professor no seu Compose
ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://+:8070" ]