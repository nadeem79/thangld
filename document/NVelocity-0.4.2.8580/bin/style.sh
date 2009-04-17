astyle --style=kr -N -O -S $1
unexpand $1 > $1.unexpand
cp $1.unexpand $1
rm $1.unexpand
rm -f $1.orig