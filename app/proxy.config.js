const proxy = [
  {
    context: '/apí',
    target: 'http://127.0.0.1:5000/api',
    pathRewrite: { '^/api' : ''}
  }
];

module.exports = proxy;
