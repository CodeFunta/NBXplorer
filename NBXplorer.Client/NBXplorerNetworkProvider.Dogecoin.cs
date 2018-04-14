﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NBXplorer
{
    public partial class NBXplorerNetworkProvider
    {
		private void InitDogecoin(ChainType chainType)
		{
			NBitcoin.Altcoins.Dogecoin.EnsureRegistered();
			Add(new NBXplorerNetwork()
			{
				CryptoCode = "DOGE",
				MinRPCVersion = 140200,
				NBitcoinNetwork = chainType == ChainType.Main ? NBitcoin.Altcoins.Dogecoin.Mainnet :
								  chainType == ChainType.Test ? NBitcoin.Altcoins.Dogecoin.Testnet :
								  chainType == ChainType.Regtest ? NBitcoin.Altcoins.Dogecoin.Regtest : throw new NotSupportedException(chainType.ToString()),
				DefaultSettings = NBXplorerDefaultSettings.GetDefaultSettings(chainType),
				ChainLoadingTimeout = TimeSpan.FromHours(1),
				SupportCookieAuthentication = false
			});
		}

		public NBXplorerNetwork GetDOGE()
		{
			return GetFromCryptoCode("DOGE");
		}
	}
}
