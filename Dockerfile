FROM mcr.microsoft.com/dotnet/sdk:8.0

# 安裝必要工具
RUN apt-get update && apt-get install -y \
    curl \
    tar \
    gzip \
    unzip \
    libicu-dev \
    libssl-dev \
    libkrb5-3 \
    zlib1g \
    liblzma-dev

# 建立 debugger 目錄
RUN mkdir -p /vsdbg

# 安裝 .NET Debugger（vsdbg）
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

# 設定工作目錄
WORKDIR /app
