const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
  app.use(
    '/api/*',
    createProxyMiddleware({
      target: 'https://localhost:44316/',
      changeOrigin: true,
      pathRewrite: {
        '^/api': '',
      },
    })
  );
};
