xmlstarlet ed -O -L -u "//Namespace/Docs/summary" -v "$2" "$1"
sed -i "" -e 's:qx:<:g' $1
sed -i "" -e 's:xq:>:g' $1
sed -i "" -e 's/"\/>/" \/>/' $1
sed -i "" -e 's/Parameters\/>/Parameters \/>/' $1
sed -i "" -e 's/Interfaces\/>/Interfaces \/>/' $1
sed -i "" -e 's/langword="true"\/>/langword="true" \/>/' $1
sed -i "" -e 's/langword="false"\/>/langword="false" \/>/' $1