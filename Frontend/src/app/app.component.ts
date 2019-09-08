import { Component, LOCALE_ID, Inject } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { IntlService, CldrIntlService } from '@progress/kendo-angular-intl';
import { registerLocaleData } from '@angular/common';

import localePt from '@angular/common/locales/pt';


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  providers: [CldrIntlService, {
    provide: IntlService,
    useExisting: CldrIntlService
  }]
})
export class AppComponent {
  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    public intl: IntlService,
    @Inject(LOCALE_ID) public localeId: string
  ) {
    this.initializeApp();
  }

  public onLocaleChange(locale: string): void {
    
    this.localeId = locale; 
    (<CldrIntlService>this.intl).localeId = locale;

    this.onChangeAngularLocale(locale);
  }

  public onChangeAngularLocale(locale: string): void {
    switch(locale) { 
      case "pt-BR": { 
        registerLocaleData(localePt);
         break; 
      } 
      default: { 
        registerLocaleData(localePt); 
         break; 
      } 
   }
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();

      this.onLocaleChange("pt-BR");

    });
  }
}
