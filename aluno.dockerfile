FROM mcr.microsoft.com/dotnet/sdk:8.0 AS debug
WORKDIR /src

COPY ["SistemaAcademicoAlunoMS/SistemaAcademicoAlunoMS.csproj", "SistemaAcademicoAlunoMS/"]
RUN dotnet restore "SistemaAcademicoAlunoMS/SistemaAcademicoAlunoMS.csproj"

COPY . .

# MUITO IMPORTANTE: Entrar na pasta para os comandos abaixo funcionarem
WORKDIR "/src/SistemaAcademicoAlunoMS"

RUN dotnet build "SistemaAcademicoAlunoMS.csproj" -c Release -o /app/build

# Porta correta para o Professor no seu Compose
ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://+:8050" ]
