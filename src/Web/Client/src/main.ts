import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/app.module';
import { } from '@angular/compiler';


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
