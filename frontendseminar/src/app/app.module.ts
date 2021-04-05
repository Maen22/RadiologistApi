import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from 'src/shared/shared.module';

// OKTA IMPORTS
import { OKTA_CONFIG, OktaAuthModule } from '@okta/okta-angular';

// Firebase IMPORTS
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { AngularFireStorageModule } from '@angular/fire/storage';
import { AngularFireModule } from '@angular/fire';

// Configs IMPORT
import { environment } from 'src/environments/environment';

// Routing IMPORT
import { AppRoutingModule } from './app-routing.module';

// App Components IMPORT
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

const config = {
  issuer: 'https://dev-54465192.okta.com/oauth2/default',
  clientId: '0oabobmm8QJX0mbQL5d6',
  redirectUri: window.location.origin + '/login/callback',
  scopes: ['openid', 'profile', 'email'],
  pkce: true,
  postLogoutRedirectUri: 'http://localhost:4200/',
};

@NgModule({
  declarations: [AppComponent, HomeComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SharedModule,
    OktaAuthModule,
    AngularFireStorageModule,
    AngularFireDatabaseModule,
    AngularFireModule.initializeApp(environment.firebase),
  ],
  providers: [{ provide: OKTA_CONFIG, useValue: config }],
  bootstrap: [AppComponent],
})
export class AppModule {}
