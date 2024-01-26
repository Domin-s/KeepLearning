import { EnvironmentPlugin } from 'webpack';

module.exports = {
  plugins: [
    new EnvironmentPlugin([
      'SERVER_BACKEND_URL'
    ])
  ],
}