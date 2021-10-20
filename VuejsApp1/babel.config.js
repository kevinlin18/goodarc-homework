module.exports = {
  presets: [
    [
      '@vue/cli-plugin-babel/preset',
      {
        polyfills: ['es6.symbol'],
        useBuiltIns: 'entry'
        }
    ]
  ]
};
