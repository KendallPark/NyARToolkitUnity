find ./ -type f |
while read file; do
    if [ "`head -c 2 -- "$file"`" == $'\xff\xfe' ]
    then
        echo "Problems with: $file"
        # If you want to convert to UTF-8 uncomment these lines.
        cat "$file" | iconv -f UTF-16 -t UTF-8 > "$file.tmp"
        mv -f "$file.tmp" "$file"
    fi
done
