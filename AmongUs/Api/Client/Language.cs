using System;

namespace AmongUs.Api {
	public static class Language
	{
		public static event Action<LanguageButton> ChangeEvent;

		public static void Change(LanguageButton button) => ChangeEvent?.Invoke(button);
	}
}
